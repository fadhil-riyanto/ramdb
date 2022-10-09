namespace ramdb.src
{
        class middleware
        {
                public static void deleteAutoAfter(Dictionary<string, object[]>[] mem, int dbnum)
                {
                        foreach (string data in mem[dbnum].Keys.ToArray<string>())
                        {
                                DateTime foo = DateTime.Now;
                                long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
                                if ((long)mem[dbnum][data][1] != 0) {
                                        if ((long)mem[dbnum][data][1] < unixTime) {
                                                mem[dbnum].Remove(data);
                                        } 
                                } 
                        }
                }
        }
}
