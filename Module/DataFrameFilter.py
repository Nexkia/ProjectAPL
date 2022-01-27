
class DataFrameFilter:
    def __call__(self, listDF, prezzo, socket, tipo_ram, tdp_gpu, vram, watt, mem_capienza, tipo_mem, size_case,
                 ram_capienza):
        # Effettuo una copia della lista dei dataframe in modo da non modificare la lista originale
        self.listDF = listDF.copy()
        return self.Filter(self.listDF, prezzo, socket, tipo_ram, tdp_gpu, vram, watt, mem_capienza, tipo_mem, size_case,
                           ram_capienza)

    '''
    Gli indici corrispondo alle seguenti categorie:
    0 casepc        1 processore        2 schedaVideo 
    3 schedaMadre   4 alimentatore      5 ram
    6 memoria       7 dissipatore
    '''

    def Filter(self, listDF, prezzo, socket, tipo_ram, tdp_gpu, vram, watt, mem_capienza, tipo_mem, size_case,
               ram_capienza):
        # Ogni dataframe viene prima filtrata per prezzo, non deve essere maggiore o uguale al prezzo fornito
        for i in range(len(listDF)):
            listDF[i] = listDF[i].loc[listDF[i]['prezzo'] <= prezzo]
        listDF[0] = listDF[0].loc[listDF[0]["taglia"].str.contains(size_case)]
        listDF[1] = listDF[1].loc[listDF[1]["socket"].str.contains(socket)]
        listDF[2] = listDF[2].loc[listDF[2]["tdp"] <= tdp_gpu]
        listDF[2] = listDF[2].loc[listDF[2]["vram"] <= vram]
        listDF[3] = listDF[3].loc[listDF[3]["cpusocket"].str.contains(socket)]
        listDF[3] = listDF[3].loc[listDF[3]["ram"].str.contains(tipo_ram)]
        listDF[4] = listDF[4].loc[listDF[4]["watt"] <= watt]
        listDF[5] = listDF[5].loc[listDF[5]["standard"].str.contains(tipo_ram)]
        listDF[5] = listDF[5].loc[listDF[5]["capienza"] <= ram_capienza]
        # Cerco all'interno dei dissipatori se trovo un dissipatore compatibile
        # con il socket cpu desiderato e mi salvo le posizioni occupate nel dataframe
        # in modo da estrarre solamente quelli compatibili
        list_index = []
        index = 0
        for _, cooler in listDF[7]["cpusocket"].items():
            for diss in cooler:
                if diss in socket:
                    list_index.append(index)
            index += 1
        list_index.sort()
        listDF[6] = listDF[6].loc[listDF[6]["tipo"].str.contains(tipo_mem)]
        listDF[6] = listDF[6].loc[listDF[6]["capienza"] <= mem_capienza]
        listDF[7] = listDF[7].loc[listDF[7].index[list_index]]
        return listDF
