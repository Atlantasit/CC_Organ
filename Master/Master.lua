--This programm was written by Atlantasit
rednet.open("back")
print("Selected Song")
print("-------------")

    Songlist = fs.list("disk/")

    print(Songlist[1])
    print("Starting in 5 seconds")
    print("------------")
    os.sleep(100)

local h = fs.open("disk/"..Songlist[1],"r")
line = h.readLine()


--Normal note reading and broadcasting
time = 0
lastbroadcast = 200


while lastbroadcast > time do
    count = 1

    for word in string.gmatch(line,'([^,]+)') do
        info[count] = word
        count = count + 1
    end

    if time == tonumber(info[1]) then

        rednet.broadcast(info[2].."_"..info[3])
        print(info[3])
        -- Modified for whistle only
        --rednet.broadcast("whistle_"..info[3])
        line = h.readLine()
        lastbroadcast = time + 200

    
    else

        time = time + 1
        os.sleep(0.1)

    end
end

h.close()