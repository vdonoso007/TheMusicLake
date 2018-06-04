using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicLake.businessLogic;
using TheMusicLake.classes;
using TheMusicLake.enums;

namespace TheMusicLake
{
    class Program
    {
        static void Main(string[] args)
        {

            string yourResponse = "";

            InitSounds();
            ExceptionSounds();
            DefinedSongs();

            do
            {
                Console.Clear();

                Console.WriteLine("Please, enter a sound of the following list: \n");
                Console.WriteLine("Frog: brr, birip, brrah, croac \n");
                Console.WriteLine("Dragonfly: fiu, plop, pep \n");
                Console.WriteLine("Criket: cric-cric, trri-trri, bri-bri \n");

                string res = Console.ReadLine();

                string song = DataService.instance.Reproduce(new Sound(res));

                Console.WriteLine("Reproducing {0} \n", song);


                Console.WriteLine("Would you like to reproduce another song? (Y)Yes/(N)No");  
                yourResponse = Console.ReadLine(); 


            } while (yourResponse.ToLower().Equals("y"));
            

        }

        static void InitSounds()
        {
            // Froag sounds
            DataService.instance.AddSoundsByAnimal(animal.Frog, new Sound("brr"));
            DataService.instance.AddSoundsByAnimal(animal.Frog, new Sound("brr"));
            DataService.instance.AddSoundsByAnimal(animal.Frog, new Sound("birip"));
            DataService.instance.AddSoundsByAnimal(animal.Frog, new Sound("brrah"));
            DataService.instance.AddSoundsByAnimal(animal.Frog, new Sound("croac"));

            // Dragonfly sounds
            DataService.instance.AddSoundsByAnimal(animal.Frog, new Sound("fiu"));
            DataService.instance.AddSoundsByAnimal(animal.Frog, new Sound("plop"));
            DataService.instance.AddSoundsByAnimal(animal.Frog, new Sound("pep"));

            // Cricket sounds
            DataService.instance.AddSoundsByAnimal(animal.Frog, new Sound("cric-cric"));
            DataService.instance.AddSoundsByAnimal(animal.Frog, new Sound("trri-trri"));
            DataService.instance.AddSoundsByAnimal(animal.Frog, new Sound("bri-bri"));

        }

        static void ExceptionSounds()
        {
            DataService.instance.exceptionSounds = new List<Sound>()
            {
                new Sound("croac"),
                new Sound("brrah")
            };
        }

        static void DefinedSongs()
        {

            DataService.instance.songs = new List<List<Song>>()
            {
                new List<Song>()
                {
                    new Song("brr"),
                    new Song("fiu"),
                    new Song("cric-cric"),
                    new Song("brrah")
                },
                new List<Song>()
                {
                    new Song("pep"),
                    new Song("birip"),
                    new Song("trri-trri"),
                    new Song("croac")
                },
                new List<Song>()
                {
                    new Song("bri - bri"),
                    new Song("plop"),
                    new Song("cric - cric"),
                    new Song("brrah")
                }
            };

        }


    }
}
