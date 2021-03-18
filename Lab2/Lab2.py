a = [6,7,2,1,9,8,4,3,5]

##Бинарная поиск
def BinSearch(arr, x):
    i = 0
    j = len(arr)-1
    while i < j:
        m = (i+j)//2
        if x > arr[m]:
            i = m+1
        else:
            j = m
    if arr[j] == x:
        return j
    else:
        return -1
           
           




a.sort()
print(BinSearch(a,4))