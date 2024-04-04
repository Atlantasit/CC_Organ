-- This is a Setup for the Slave Disk Drive
--This programm was written by Atlantasit

notes = 
{
        -- Under Octaves are marked with a _-1 after the instroment tag            
            {"-1", "0.500000", "F#1"},
            {"-1", "0.529732", "G1"},
            {"-1", "0.561231", "G#1"},
            {"-1", "0.594604", "A1"},
            {"-1", "0.629961", "A#1"},
            {"-1", "0.667420", "B1"},
            {"-1", "0.707107", "C2"},
            {"-1", "0.749154", "C#2"},
            {"-1", "0.793701", "D2"},
            {"-1", "0.840896", "D#2"},
            {"-1", "0.890899", "E2"},
            {"-1", "0.943874", "F2"},
        -- Create steam whistle range start [13]
            {"-1", "1.000000", "F#2"},
            {"-1", "1.059463", "G2"},
            {"-1", "1.122462", "G#2"},
            {"-1", "1.189207", "A2"},
            {"-1", "1.259921", "A#2"},
            {"-1", "1.334840", "B2"},
            {"-1", "1.414214", "C3"},
            {"-1", "1.498307", "C#3"},
            {"-1", "1.587401", "D3"},
            {"-1", "1.681793", "D#3"},
            {"-1", "1.781797", "E3"},
            {"-1", "1.887749", "F3"},
        -- Start of the normal Range for Noteblocks [25]
            {"0", "0.500000", "F#3"},
            {"0", "0.529732", "G3"},
            {"0", "0.561231", "G#3"},
            {"0", "0.594604", "A3"},
            {"0", "0.629961", "A#3"},
            {"0", "0.667420", "B3"},
            {"0", "0.707107", "C4"},
            {"0", "0.749154", "C#4"},
            {"0", "0.793701", "D4"},
            {"0", "0.840896", "D#4"},
            {"0", "0.890899", "E4"},
            {"0", "0.943874", "F4"},
            --
            {"0", "1.000000", "F#4"},
            {"0", "1.059463", "G4"},
            {"0", "1.122462", "G#4"},
            {"0", "1.189207", "A4"},
            {"0", "1.259921", "A#4"},
            {"0", "1.334840", "B4"},
            {"0", "1.414214", "C5"},
            {"0", "1.498307", "C#5"},
            {"0", "1.587401", "D5"},
            {"0", "1.681793", "D#5"},
            {"0", "1.781797", "E5"},
            {"0", "1.887749", "F5"},
            {"0", "2.000000", "F#5"},
        -- End of the Normal Range for Noteblocks and for Create steam whistle [49]
        -- Upper Octaves are marked with a _1 after the instroment tag
            {"1", "0.529732", "G5"},
            {"1", "0.561231", "G#5"},
            {"1", "0.594604", "A5"},
            {"1", "0.629961", "A#5"},
            {"1", "0.667420", "B5"},
            {"1", "0.707107", "C6"},
            {"1", "0.749154", "C#6"},
            {"1", "0.793701", "D6"},
            {"1", "0.840896", "D#6"},
            {"1", "0.890899", "E6"},
            {"1", "0.943874", "F6"},
            {"1", "1.000000", "F#6"},
            {"1", "1.059463", "G6"},
            {"1", "1.122462", "G#6"},
            {"1", "1.189207", "A6"},
            {"1", "1.259921", "A#6"},
            {"1", "1.334840", "B6"},
            {"1", "1.414214", "C7"},
            {"1", "1.498307", "C#7"},
            {"1", "1.587401", "D7"},
            {"1", "1.681793", "D#7"},
            {"1", "1.781797", "E7"},
            {"1", "1.887749", "F7"},
            {"1", "2.000000", "F#7"}
        -- Total notes [73]
        }

        instroments =
        {
            "harp",
            "bass",
            "snare",
            "hat",
            "basedrum",
            "bell",
            "flute",
            "chime",
            "guitar",
            "xylophone",
            "iron_xylophone",
            "cow_bell",
            "didgeridoo",
            "bit",
            "banjo",
            "pling",
            "whistle"
        }

    -- Slave Programms for da normal Noteblocks
    -- pls dont mind the f*ing hyper nesting
    -- For every Instroment there is now a Setup Disk cause disk space limitations

    for j = 1,16 do
        for i = 25,49 do
            local file = fs.open("disk"..j.."/Slave_"..instroments[j].."_"..notes[i][3],"w")

                file.writeLine("local file = fs.open('startup','w')")
                file.writeLine("file.writeLine("..'"'.."shell.run('Slave_"..instroments[j].."_"..notes[i][3].."')"..'"'..")")
                file.writeLine("file.close()")

                file.writeLine('    local file = fs.open("Slave_'..instroments[j]..'_'..notes[i][3]..'","w")            ')
                file.writeLine('    file.writeLine("rednet.open('.."'bottom'"..')")                                     ')
                file.writeLine('    file.writeLine("while true do")                                                     ')
                file.writeLine('    file.writeLine("id , msg = rednet.receive()")                                       ')
                file.writeLine("    file.writeLine('if msg == "..'"'..instroments[j].."_"..notes[i][3]..'"'.." then')   ") 
                    --  /|\   This line was and is PAIN  /|\
                file.writeLine('    file.writeLine("redstone.setOutput('.."'back'"..',true)")                           ')
                file.writeLine('    file.writeLine("sleep(0.2)")                                                        ')
                file.writeLine('    file.writeLine("redstone.setOutput('.."'back'"..',false)")                          ')
                file.writeLine('    file.writeLine("end end")                                                           ')
                file.writeLine('    file.close()                                                                        ')
                file.writeLine('    shell.run("startup")                                                                ')

            file.close()
        end
    end

    -- Slave Programms for da Create whistle 
    j = 17
    for i = 13,49 do
        local file = fs.open("disk"..j.."/Slave_"..instroments[j].."_"..notes[i][3],"w")

        file.writeLine("local file = fs.open('startup','w')")
        file.writeLine("file.writeLine("..'"'.."shell.run('Slave_"..instroments[j].."_"..notes[i][3].."')"..'"'..")")
        file.writeLine("file.close()")

        file.writeLine('    local file = fs.open("Slave_'..instroments[j]..'_'..notes[i][3]..'","w")            ')
        file.writeLine('    file.writeLine("rednet.open('.."'bottom'"..')")                                     ')
        file.writeLine('    file.writeLine("while true do")                                                     ')
        file.writeLine('    file.writeLine("id , msg = rednet.receive()")                                       ')
        file.writeLine("    file.writeLine('if msg == "..'"'..instroments[j].."_"..notes[i][3]..'"'.." then')   ")
                                --  /|\   This line was and is PAIN  /|\
        file.writeLine('    file.writeLine("redstone.setOutput('.."'back'"..',true)")                           ')
        file.writeLine('    file.writeLine("sleep(0.2)")                                                        ')
        file.writeLine('    file.writeLine("redstone.setOutput('.."'back'"..',false)")                          ')
        file.writeLine('    file.writeLine("end end")                                                           ')
        file.writeLine('    file.close()                                                                        ')
        file.writeLine('    shell.run("startup")                                                                ')
        
    file.close()
    end