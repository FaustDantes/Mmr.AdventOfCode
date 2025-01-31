namespace Mmr.Aoc2024.Days;

public class Day09A : DayAbstract {
    protected override void Runner(Reader reader) {
        string input = reader.ReadAll();
        var disk = ParseDisk(input);
        CompactDisk(disk);
        Result = CalculateChecksum(disk);
    }
    private static List<char> ParseDisk(string input) {
        List<char> disk = new();
        int fileId = 0;

        for (int i = 0; i < input.Length; i++) {
            int length = input[i] - '0';
            if (i % 2 == 0) {
                disk.AddRange(Enumerable.Repeat((char)('0' + fileId), length));
                fileId++;
                continue;
            }

            disk.AddRange(Enumerable.Repeat('.', length));
        }
        return disk;
    }

    private static void CompactDisk(List<char> disk) {
        int writeIndex = disk.Count - 1;

        for (int readIndex = 0; readIndex < disk.Count && readIndex != writeIndex; readIndex++) {
            if (disk[readIndex] != '.') continue;
            if (disk[writeIndex] == '.') continue;

            (disk[writeIndex], disk[readIndex]) = (disk[readIndex], disk[writeIndex]);
            writeIndex = disk.Index().Where(x => x.Item != '.').Max().Index;
        }
    }

    static int CalculateChecksum(List<char> disk) {
        int checksum = 0;
        for (int i = 0; i < disk.Count; i++) {
            if (disk[i] != '.') {
                checksum += i * (disk[i] - '0');
            }
        }
        return checksum;
    }
}