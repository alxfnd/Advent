import re

def GridID(GridList: list, fromx, fromy, tox, toy):
    newlist = []
    newx: int
    newy: int
    if tox > fromx:
        newx = fromx
        newy = fromy
        while tox > newx:
            newx += 1
            string = (f"{newx},{newy}")
            newlist.append(string)
    elif tox < fromx:
        newx = fromx
        newy = fromy
        while tox < newx:
            newx -= 1
            string = (f"{newx},{newy}")
            newlist.append(string)
    elif toy > fromy:
        newx = fromx
        newy = fromy
        while toy > newy:
            newy = newy + 1
            string = (f"{newx},{newy}")
            newlist.append(string)
    elif toy < fromy:
        newx = fromx
        newy = fromy
        while toy < newy:
            newy -= 1
            string = (f"new")
            newlist.append(string)
    return newlist
            
            
GridList = []
Advent = open("c:\\Users\\alexf\\OneDrive\\Documents\\AdventofCode\\22\\Day14.txt", "r")
for line in Advent:
    newline = re.sub(' ->', '', line)
    newline = re.sub('\n', '', newline)
    newline = re.split(' ', newline)
    count = 0
    while count < (newline.__len__() - 1):
        fromx: int = re.split(',', newline[count])[0]
        fromy: int = re.split(',', newline[count])[1]
        tox: int = re.split(',', newline[(count + 1)])[0]
        toy: int = re.split(',', newline[(count + 1)])[1]
        if fromx == tox:
            if fromy > toy:
                newy = toy
                for i in range(toy.__int__(), fromy.__int__()):
                    GridList += f"{fromx, newy}"
                    newy += 1
            else:
                newy = fromy
                for i in range(fromy.__int__(), toy.__int__()):
                    GridList += f"{fromx, newy}"
                    newy += 1
        #GridList += GridID(GridList=GridList, fromx=fromx, fromy=fromx, tox=tox, toy=toy)
        count += 1
    print(GridList)