import pandas as pd


class DataFrameFilter:
    def __init__(self, listDF):
        # Effettuo una copia della lista dei dataframe in modo da non modificare la lista originale
        self.listDF = listDF.copy()

    '''
    Gli indici corrispondo alle seguenti categorie:
    0 casepc    1 cpu       2 gpu 
    3 mb        4 psu       5 ram
    6 mem       7 cooler
    '''

    def Filter(self, listDF, prezzo, socket, tipo_ram, tdp_gpu, vram, watt, mem_capienza, tipo_mem, size_case,
              ram_capienza):
        self.listDF = listDF.copy()
        for i in range(len(self.listDF)):
            self.listDF[i] = self.listDF[i].loc[self.listDF[i]['prezzo'] <= prezzo]
        self.listDF[0] = self.listDF[0].loc[self.listDF[0]["taglia"].str.contains(size_case)]
        self.listDF[1] = self.listDF[1].loc[self.listDF[1]["socket"].str.contains(socket)]
        self.listDF[2] = self.listDF[2].loc[self.listDF[2]["tdp"] <= tdp_gpu]
        self.listDF[2] = self.listDF[2].loc[self.listDF[2]["vram"] <= vram]
        self.listDF[3] = self.listDF[3].loc[self.listDF[3]["cpusocket"].str.contains(socket)]
        self.listDF[3] = self.listDF[3].loc[self.listDF[3]["ram"].str.contains(tipo_ram)]
        self.listDF[4] = self.listDF[4].loc[self.listDF[4]["watt"] <= watt]
        self.listDF[5] = self.listDF[5].loc[self.listDF[5]["standard"].str.contains(tipo_ram)]
        self.listDF[5] = self.listDF[5].loc[self.listDF[5]["capienza"] <= ram_capienza]
        list_index = []
        index = 0
        for _, sckt in self.listDF[7]["cpusocket"].items():
            for diss in sckt:
                if diss in socket:
                    list_index.append(index)
            index += 1
        list_index.sort()
        self.listDF[6] = self.listDF[6].loc[self.listDF[6]["tipo"].str.contains(tipo_mem)]
        self.listDF[6] = self.listDF[6].loc[self.listDF[6]["capienza"] <= mem_capienza]
        self.listDF[7] = self.listDF[7].loc[self.listDF[7].index[list_index]]
        return self.listDF
