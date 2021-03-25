def isMnogougol():
    print("Введите кол-во вершин")
    N = int(input())
    if N < 4:
        return -1
    if N % 3 == 0:
        return 3
    if N % 4 == 0:
        return 4
    return N
print(isMnogougol()) 