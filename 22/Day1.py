Advent = open("C:\\Users\\alexf\\OneDrive\\Documents\\AdventofCode\\22\\Day1.txt", "r")
Advent = Advent.readlines()
Part1 = []
Score = 0
for line in Advent:
        if not line.isspace():
            val = int(line)
            Score += val
        else:
            Part1.append(Score)
            Score = 0
Part1.append(Score)
Part1.sort(reverse = True)
print(Part1[0])
print((Part1[0] + Part1[1] + Part1[2]))