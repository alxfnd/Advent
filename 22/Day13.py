import re
Advent = open("C:\\Users\\alexf\\OneDrive\\Documents\\AdventofCode\\22\\Day13.txt", "r")
Advent = Advent.readlines()
Array = []
def GetCompare(text):
    AllVals = []
    index = 0
    while True:
        str = ""
        arr = 0
        for c in text[index:-1]:
            index += 1
            if c == "[":
                arr += 1
            if c == "]":
                arr -= 1
            if c == "," and arr == 0:
                AllVals.append(str)
                break
            str += c
        if index == (len(text) - 1):
            break
    AllVals.append(str)
    #print(AllVals)
    return AllVals

turn = 0
for line in Advent:
    if not line.isspace():
        arrayiter = line.__iter__()
        line = line.replace('\n','')
        #line = line.removeprefix("[").removesuffix("]")
        #line = [line]
        #iter = line.__iter__()
        #print(line.__len__())
        if line.__contains__(","):
            if turn == 0:
                left = GetCompare(line[1:])
                turn = 1
            else:
                right = GetCompare(line[1:])
                turn = 0
        else:
            if turn == 0:
                left = [line]
                turn = 1
            else:
                right = [line]
                turn = 0
    else:
        ind = 0
        total = 0
        if left < right:
            print(f"{left}\n{right}\nsuccess\n")
            continue
        elif right < left:
            print(f"{left}\n{right}\nfailure\n")
            continue
        # could probably do this with just left count
        if left.__len__() > right.__len__():
            total = left.__len__()
        else:
            total = right.__len__()
        print(left)
        print(right)
        while ind < total:
            #print(ind)
            newleft = left[ind]
            newright = right[ind]
            while newleft.__contains__(",") or newright.__contains__(","):
                if newleft.__contains__(","):
                    newleft = GetCompare(newleft)
                    if newright.__contains__(","):
                        newright = GetCompare(newright)
                    else:
                        newright = [newright]
                else:
                    newleft = [newleft]
                    newright = GetCompare(newright)
            if newleft < newright:
                print("success")
                break
            elif newleft > newright:
                print("failure")
                break
            ind = ind + 1
            if (ind + 1) == left.__len__():
                print("success")
                break
            elif (ind + 1) > right.__len__():
                print("failure")
                break
        
    
    """
    if not line.isspace():
        if line.__contains__(","):
            if turn == 0:
                left = GetCompare(line[1:-1])
                turn += 1
            else:
                right = GetCompare(line[1:-1])
                turn = 0
        else:
            if turn == 0:
                left = line[0:-1]
                turn += 1
            else:
                right = line[0:-1]
                turn = 0
    else:
        valcount = 0
        #print(f'This is pair: {valcount + 1}')
        lnumber = re.sub('[\D]', '', left[valcount])
        rnumber = re.sub('[\D]', '', right[valcount])
        #print(left)
        #print(right)
        #if not (left[valcount].__contains__(",")) and not (right[valcount].__contains__(",")) :
            #if lnumber.__len__() != 0:
                #print(lnumber[0])
           # else:
                #print(left)
            #if rnumber.__len__() != 0:
                #print(rnumber[0])
            #else:
                #print(right)
        #while (valcount < left.count(int)):
            
            ####valcount += 1
  """          

#print(line)
#print(line.replace("[","").replace("]",""))