print ("Input N")
N = int(input())
str = []
for i in range(0,N,1):
	str.append(input())
result = " "
for d in range(0,N,1):
	max1 = " "
	max2 = " "
	ind = 0

	for i in range(0,N,1):
		if str[i][0] > max1[0]:
			max1 = str[i]
			ind = i
	str[ind] = " "

	for i in range(0,N,1):
		if str[i][0] > max2[0]:
			max2 = str[i]
			ind = i
	str[ind] = " "
	maxima = True
	if max1[0] == max2[0] and max1[0] != ' ':
		l = 0
		if len(max1) > len(max2):
			l = len(max2)
		else:
			l = len(max1)

			for j in range(0,l,1):
				if max1[j] > max2[j]:
					maxima = True
					break
				if max1[j] < max2[j]:
					maxima = False
					break
	print(max1)
	print(max2)
	if max1[0] != ' ' and maxima:
		result+=max1
		if max2[0] != ' ':
			result+=max2
	else:
		if max2[0] != ' ':
			result+=max2
		if max1[0] != ' ':
			result +=max1

print(maxima)			
print(result)

	
	

