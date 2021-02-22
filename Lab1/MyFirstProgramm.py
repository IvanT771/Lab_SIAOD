a = [1,6,3,9,8,2,4,7,5]

#Сортировка выбором 
# for i in range(0,len(a),1):
#     minIndex = i
#     for j in range(i+1,len(a),1):
#         if a[j] < a[minIndex]:
#             minIndex = j
#     buf = a[i]
#     a[i] = a[minIndex]
#     a[minIndex] = buf
#Сортировка вставкой
# for i in range(1,len(a),1):
#     buf = a[i]
#     j = i - 1
#     while j>=0 and a[j] > buf:
#         a[j+1] = a[j]
#         j=j-1
#     a[j+1] = buf
#Сортировка обменом
# for i in range(1,len(a),1):
#     for j in range(1,len(a)-1,1):
#         if a[j] > a[j+1]:
#             buf = a[j]
#             a[j] = a[j+1]
#             a[j+1] = buf
#Сортировка Шелла
d=len(a)
d=d//2
while d>0:
    for i in range(0,len(a)-d,1):
        j=i
        while j>=0 and a[j] > a[j+d]:
            buf=a[j]
            a[j]=a[j+d]
            a[j+d]=buf
            j=j-1
    d=d//2

print(a)