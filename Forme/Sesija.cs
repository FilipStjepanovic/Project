using Domen;

namespace Forme
{
    public class Sesija
    {
        private static Sesija _instance;
        public static Sesija Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Sesija();
                }
                return _instance;
            }
        }
        private Sesija() { }

        public Radnik Radnik { get; set; }
    }
}
