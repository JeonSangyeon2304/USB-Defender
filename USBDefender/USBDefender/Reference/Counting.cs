namespace USBDefender
{
    class Counting
    {
        public int count(string[] array)
        {
            int cnt = 0;
            int i = 0;
            while (true)
            {
                try
                {
                    if (array[i] != null)
                        cnt++;
                }
                catch
                {
                    break;
                }
                i++;
            }


            return cnt;
        }
    }
}
