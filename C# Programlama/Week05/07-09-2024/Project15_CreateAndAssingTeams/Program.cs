namespace Project15_CreateAndAssingTeams;

class Program
{
    static void Main(string[] args)
    {
       string[] students = {
        "Hakan Çaktı",
        "Tunacan Eşki",
        "Elif Öztürk",
        "Rojin Çetiz",
        "Ömer Taştekin",
        "Enes Kılıçaslan",
        "Atlas Uyar",
        "Erdem Yüce Gül",
        "Enes can Aydemir",
        "Irmak Özen",
        "Burhan Torun",
        "Miraç Katmer",
        "Bedirhan Çaylı",
        "Melina Balcı",
        "Merve Kahraman",
        "Kerem Can Kırpar",
        "Gizem Yüksel",
        "Celal Uğur Koçan",
        "Tahir Burak Avar",
        "Samet Önür",
        "Aleyna Çelen",
        "Elifnur Binici",
        "Doğukan Babayiğit",
        "Emre Kılıç"
       };
       
       string[] teamNames = {
        "Debuggers",
        "CodeWars",
        "Algorictmics",
        "BinaryCoders",
        "NullPointers",
        "DevDynamics"
       };

       double memberCount = 4;
       int teamCount = (int)Math.Ceiling(students.Length / memberCount);

       string[] teams = new string[teamCount];
        //Rastgele Öğrenci Atama Yaptık
       Random rn = new Random();
       int randomIndex;
       for(int i = 0; i < students.Length; i++)
       {
            randomIndex = rn.Next(students.Length);
            string temp = students[i];
            students[i]= students[randomIndex];
            students[randomIndex] = temp;
       }

           int teamCounter = 0;
            string currentTeamName;
        for (int i = 0; i < students.Length; i+=4)
        {
            currentTeamName = teamNames[teamCounter];
            Console.WriteLine($"Takım Adı: {currentTeamName} ");
            for(int j = 0; j < memberCount; j++)
            {
                Console.WriteLine($"\t\t-{students[i+j]}");
            }
            Console.WriteLine();
            teamCounter++;
        }










    //    foreach(string item in students)
    //    {
    //     Console.WriteLine(item + "\n-------------");
    //    }

       

       
    }
}
