namespace LibraryHelper
{
    public class ReadFile
    {
        private static ReadFile instance = null;
        private static readonly object instacelock = new object();

        private ReadFile()
        {

        }

        public static ReadFile Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReadFile();
                }
                return instance;
            }
        }

        public List<List<int>> ReadAndSplitFile(string filePath)
        {
            List<List<int>> result = new List<List<int>>();

            foreach (var line in File.ReadLines(filePath))
            {
                List<int> row = new List<int>();
                var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var part in parts)
                {
                    if (int.TryParse(part, out int num))
                    {
                        row.Add(num);
                    }
                }
                result.Add(row);
            }

            return result;
        }

        public int[][] ReadAndSplitFileByColumns(string filePath)
        {
            List<List<int>> columns = new List<List<int>>();

            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                // Ensure the columns list is large enough to accommodate the current line
                for (int i = columns.Count; i < parts.Length; i++)
                {
                    columns.Add(new List<int>());
                }

                for (int i = 0; i < parts.Length; i++)
                {
                    if (int.TryParse(parts[i], out int num))
                    {
                        columns[i].Add(num);
                    }
                }
            }

            // Convert each list in columns to an array and return as a 2D array
            return columns.Select(col => col.ToArray()).ToArray();
        }

        public string ReadFileAsString(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
