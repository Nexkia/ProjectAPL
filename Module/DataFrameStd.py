import pandas as pd

EXCLUDE = ["valutazione", "prezzo", "modello", "marca", "socket"]
CONVERSIONE = ["taglia", "tipo", "standard", "cpusocket"]
LISTAMODELLI = ["modello_casepc", "modello_cpu", "modello_schedaVideo",
                "modello_schedaMadre", "modello_alimentatore",
                "modello_ram", "modello_memoria", "modello_dissipatore"]
NUOVECOLONNE = ["col1", "col2", "col3"]


class DataFrame:

    def __init__(self, rows, columns, vendite):
        self.listDF = None
        self.createDataFrame(rows, columns, vendite)

    def createDataFrame(self, rows, columns, vendite):
        DFcasepc = pd.DataFrame(data=rows[0], columns=columns[0])
        DFcpu = pd.DataFrame(data=rows[1], columns=columns[1])
        DFgpu = pd.DataFrame(data=rows[2], columns=columns[2])
        DFmb = pd.DataFrame(data=rows[3], columns=columns[3])
        DFpsu = pd.DataFrame(data=rows[4], columns=columns[4])
        DFram = pd.DataFrame(data=rows[5], columns=columns[5])
        DFmem = pd.DataFrame(data=rows[6], columns=columns[6])
        DFcooler = pd.DataFrame(data=rows[7], columns=columns[7])
        listDF = [DFcasepc, DFcpu, DFgpu, DFmb,
                  DFpsu, DFram, DFmem, DFcooler]
        self.listDF = self.ranking(listDF, vendite)

    def ranking(self, listDF, vendite):
        list_feature = []
        # Vengono estratte tutte le colonne rilevanti per il confronto
        for df in listDF:
            list_feature.append([column for column in df.columns if column not in EXCLUDE])
        # Scheda madre senza filtri
        list_feature[3] = []
        for df, idx in zip(listDF, list_feature):
            indice = 0
            for feature in idx:
                if feature in LISTAMODELLI:
                    # il primo elemento è la lista dei modelli
                    # viene sottratto uno per non considerarlo
                    indice -= 1
                if feature in CONVERSIONE:
                    # Questo è un caso particolare dovuto al tipo del dato
                    # da elaborare, essendo una stringa ne viene fatta una
                    # conversione per estrarre delle informazioni
                    df = self.conversion(feature, df, NUOVECOLONNE[indice])
                if feature not in LISTAMODELLI and feature not in CONVERSIONE:
                    # Se le feature non solo i nomi dei modelli e non devono essere convertiti
                    # ne viene fatta la standardizzazione, sottraendo il valore medio e
                    # dividendolo per la deviazione standard, infine viene aggiunta una nuova
                    # colonna con il risultato
                    mean = round(df[feature].mean(), 4)
                    std = round(df[feature].std(), 4)
                    df[NUOVECOLONNE[indice]] = df.apply(lambda row: ((row[feature] - mean) / std), axis=1)
                    df[NUOVECOLONNE[indice]] = df[NUOVECOLONNE[indice]].round(3)
                indice += 1
            # Inizializzazione della colonna venduti
            df["venduti"] = 0
            self.addVendite(vendite, listDF)
            self.standardize(df, "venduti")
            # Infine viene calcolato uno score e ordinato in base al suo rank
            df["score"] = df.apply(lambda row: self.calculate_score(row, indice), axis=1)
            df["score"] = df["score"].fillna(0)
            df["score"] = df["score"].rank()
            df.sort_values("score", inplace=True, ascending=False)
        # schedaMadre inutile visto che non le confronto faccio un semplice ordinamento per valutazione
        del listDF[3]["score"]
        listDF[3].sort_values("valutazione", inplace=True, ascending=False)
        return listDF

    def conversion(self, feature, df, indice):
        if feature in "taglia":
            for row, i in zip(df[feature], range(len(df[feature]))):
                taglia = 0
                if row in "Big-Tower":
                    taglia = 3
                if row in "Midi-Tower":
                    taglia = 2
                if row in "Micro-ATX":
                    taglia = 1
                df.at[i, indice] = taglia
        if feature in "standard":
            for row, i in zip(df[feature], range(len(df[feature]))):
                standard = 0
                if row in "DDR3":
                    standard = 1
                if row in "DDR4":
                    standard = 2
                df.at[i, indice] = standard
        if feature in "tipo":
            for row, i in zip(df[feature], range(len(df[feature]))):
                tipo = 0
                if row in "hdd":
                    tipo = 1
                if row in "ssd":
                    tipo = 2
                df.at[i, indice] = tipo
        if feature in "cpusocket":
            for row, i in zip(df[feature], range(len(df[feature]))):
                df.at[i, indice] = len(row)
        self.standardize(df, indice)
        return df

    @staticmethod
    def calculate_score(row, index):
        result = 0
        if index != 0:
            # Sommo i valori di ogni caratteristica da confrontare
            # aggiungo il contributo delle vendite
            # peso il valore per il 20% della valutazione
            for i in range(index):
                result += row[NUOVECOLONNE[i]]
            result += row["venduti"]
            result *= row["valutazione"] * 0.2
            result = result/(index + 1)
            return result

    @staticmethod
    def addVendite(vendite, listDF):
        # Se trovo il modello o il preassemblato aggiungo
        # al valore di vendita il numero di vendite
        for key, value in vendite.items():
            for df in listDF:
                columns_df = df.columns
                for i, row in df[columns_df[0]].items():
                    if row == key:
                        df.at[i, "venduti"] = value

    @staticmethod
    def standardize(df, indice):
        mean = round(df[indice].mean(), 4)
        std = round(df[indice].std(), 4)
        df[indice] = df.apply(lambda row: ((row[indice] - mean) / std), axis=1)
        df[indice] = df[indice].round(3)
        return df
