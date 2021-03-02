print("Hello")
def Serch():
    N = int(input())
    str = []

    for i in range(0,N,1):
        str.append(input()) #ввод истории открытия/закрытия законопроектов

    begin = 0 #Точка выноса законопроекта на обсуждение
    end = 0 #Точка заверешения законпроекта 
    _close = 0 #Кол-во открытых законопроект от партии
    _open = 0 #Кол-во закрытых законопроект от партии
    save = len(str)-1 #Предыдущий конец закрытого законопроекта (изначально это последний закон.проект)
    while True:
        if end >= len(str) or begin >= len(str):
            if _open != _close:
                return "No"
            else:
                return "Yes"
        if end > save: #Если предыдущий законопроект завершен до завершения нового
            return "No"
        
        number = str[begin][len(str[begin])-1] #Номер партии

        if str[end].find("add "+number) != -1:
            _open = _open + 1 #Добавлен на обсуждение новый законопроект конкретной партией
            
        elif str[end].find("vote "+number) != -1:
            _close = _close+1 #Голосование законченно по поводу конкретноко закон.проект.
            

        if _close > _open: #Закрытых закон.проект. не может быть больше открытых
            return "NO"
        if _close == _open:
            if end-begin == 1: #Если между законопроектом нет других проектов
                if len(str)-1 != save:
                    begin = save+1
                else:
                    begin = end+1
                save = len(str)-1 #Обнулеям 
            else:    
                begin=begin+1
                save = end
            end = begin
            _close = 0
            _open = 0
        else:
            end=end+1

    return "yyyyy"
    
print(Serch())
print("End")
