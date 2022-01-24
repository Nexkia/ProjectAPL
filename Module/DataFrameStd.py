import pandas as pd


class DataFrame:

    def __init__(self, rows, columns, vendite):
        self.DFmem = None
        self.DFmb = None
        self.listDF = None
        self.DFcooler = None
        self.DFram = None
        self.DFpsu = None
        self.DFgpu = None
        self.DFcpu = None
        self.DFcasepc = None
        self.vendite = vendite
        self.exclude = ["valutazione", "prezzo", "modello", "marca", "socket"]
        self.conv = ["taglia", "tipo", "standard", "cpusocket"]
        self.listModelli = ["modello_casepc", "modello_cpu", "modello_schedaVideo",
                            "modello_schedaMadre", "modello_alimentatore", "modello_ram"
            , "modello_memoria", "modello_dissipatore"]
        self.newColumns = ["col1", "col2", "col3"]
        self.createDataFrame(rows, columns)

    def createDataFrame(self, rows, columns):
        self.DFcasepc = pd.DataFrame(data=rows[0], columns=columns[0])
        self.DFcpu = pd.DataFrame(data=rows[1], columns=columns[1])
        self.DFgpu = pd.DataFrame(data=rows[2], columns=columns[2])
        self.DFmb = pd.DataFrame(data=rows[3], columns=columns[3])
        self.DFpsu = pd.DataFrame(data=rows[4], columns=columns[4])
        self.DFram = pd.DataFrame(data=rows[5], columns=columns[5])
        self.DFmem = pd.DataFrame(data=rows[6], columns=columns[6])
        self.DFcooler = pd.DataFrame(data=rows[7], columns=columns[7])
        self.listDF = [self.DFcasepc, self.DFcpu, self.DFgpu,
                       self.DFmb, self.DFpsu, self.DFram, self.DFmem, self.DFcooler]

    def standardize(self):
        list_feature = []
        for df in self.listDF:
            list_feature.append([column for column in df.columns if column not in self.exclude])
        # Scheda madre senza filtri
        list_feature[3] = []
        for df, idx in zip(self.listDF, list_feature):
            indice = 0
            for feature in idx:
                if feature in self.listModelli:
                    indice -= 1
                if feature in self.conv:
                    df = self.conversion(feature, df, self.newColumns[indice])
                if feature not in self.listModelli and feature not in self.conv:
                    mean = round(df[feature].mean(), 4)
                    std = round(df[feature].std(), 4)
                    df[self.newColumns[indice]] = df.apply(lambda row: ((row[feature] - mean) / std), axis=1)
                    df[self.newColumns[indice]] = df[self.newColumns[indice]].round(3)
                indice += 1
            df["venduti"] = 0
            self.addVendite(self.vendite)
            df["score"] = df.apply(lambda row: self.calculate_score(row, indice), axis=1)
            df["score"] = df["score"].fillna(0)
            df["score"] = df["score"].rank()
            df.sort_values("score", inplace=True, ascending=False)
        # schedaMadre
        del self.listDF[3]["score"]
        self.listDF[3].sort_values("valutazione", inplace=True, ascending=False)
        return self.listDF

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
        mean = round(df[indice].mean(), 4)
        std = round(df[indice].std(), 4)
        df[indice] = df.apply(lambda row: ((row[indice] - mean) / std), axis=1)
        df[indice] = df[indice].round(3)
        return df

    def calculate_score(self, row, index):
        result = 0
        if index != 0:
            for i in range(index):
                result += row[self.newColumns[i]]
            result *= row["valutazione"] * 0.2
            result += row["venduti"] * 0.2
            result /= index
            return result

    def addVendite(self, vendite):
        for key, value in vendite.items():
            for df in self.listDF:
                columns_df = df.columns
                for i, row in df[columns_df[0]].items():
                    if row == key:
                        df.at[i, "venduti"] = value
