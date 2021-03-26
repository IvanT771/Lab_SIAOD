print ("Input N")
N = int(input())
str = []
for i in range(0,N,1):
	str.append(input())

##-------------Метод сравнения двух строковых чисел-----------------------
##----возвращает True - если первое число (x) больше-----------------------
def sortt(x,y):
	if len(x) == len(y):
		for j in range(0,len(x),1):
			if x[j] > y[j]:
				##print("result: "+x+y)
				return True
			if x[j] < y[j]:
				##print("result: "+y+x)
				return False
	if len(x) > len(y):
		for i in range(0,len(y),1):
			if x[i] > y[i]:
				##print("result: "+x+y)
				return True
			if x[i] < y[i]:
				##print("result: "+y+x)
				return False
		for i in range(0,len(x),1):
			if x[i] > y[len(y)-1]:
				##print("result: "+x+y)
				return True
			if x[i] < y[len(y)-1]:
				##print("result: "+y+x)
				return False
	if len(x) < len(y):
		for i in range(0,len(x),1):
			if x[i] > y[i]:
				##print("result: "+x+y)
				return True
			if x[i] < y[i]:
				##print("result: "+y+x)
				return False
		for i in range(0,len(y),1):
			if x[len(x)-1] > y[i]:
				##print("result: "+x+y)
				return True
			if x[len(x)-1] < y[i]:
				##print("result: "+y+x)
				return False
	return True
##-------------------------КОНЕЦ МЕТОДА------------------------------------

##---Сортируем числа
for i in range(0,N,1):
	for j in range(0,N,1):
		if sortt(str[i],str[j]):
			t = str[i]
			str[i] = str[j]
			str[j] = t
##--Вывод результата
result = ""
for i in range(0,N,1):
	result+=str[i]
print(result)



	





		


	
	

