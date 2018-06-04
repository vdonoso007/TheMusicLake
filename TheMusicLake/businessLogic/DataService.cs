using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMusicLake.classes;
using TheMusicLake.enums;

namespace TheMusicLake.businessLogic
{
    class DataService
    {
        public static DataService instance = new DataService();

        private List<Sound> _exceptionSounds = new List<Sound>();

        private List<Sound> _frogSounds = new List<Sound>();
        private List<Sound> _dragonflySounds = new List<Sound>();
        private List<Sound> _cricketSounds = new List<Sound>();

        private List<List<Song>> _song = new List<List<Song>>();

        public List<Sound> exceptionSounds {
            set { _exceptionSounds = value; }
        }

        public List<List<Song>> songs {
            set { _song = value; }
        }

        private bool ExistsSound(Sound sound)
        {
            if (_frogSounds.Exists(x => x.tone == sound.tone)) {
                Console.WriteLine("{0} already be in frog list", sound.tone);
                return true;
            }

            if (_dragonflySounds.Exists(x => x.tone == sound.tone)) {
                Console.WriteLine("{0} already be in dragonfly list", sound.tone);
                return true;
            }

            if (_cricketSounds.Exists(x => x.tone == sound.tone)) {
                Console.WriteLine("{0} already be in cricket list", sound.tone);
                return true;
            }

            return false;
        }

        public void AddSoundsByAnimal(animal animal, Sound sound) {

            if (ExistsSound(sound))
                return;

            switch (animal)
            {
                case animal.Frog:
                    _frogSounds.Add(sound);
                    break;
                case animal.Dragonfly:
                    _dragonflySounds.Add(sound);
                    break;
                case animal.Cricket:
                    _cricketSounds.Add(sound);
                    break;
                default:
                    break;
            }

        }

        public List<Sound> GetListSoundByAnimal(animal animal)
        {
            switch (animal)
            {
                case animal.Frog:

                    return _frogSounds;
                case animal.Dragonfly:
                    return _dragonflySounds;
                case animal.Cricket:
                    return _cricketSounds;
                default:
                    return null;
            }
        }

        public string Reproduce(Sound sound)
        {
            string result = "";
            List<string> tones = new List<string>();
            if (_exceptionSounds.Exists(x => x.tone == sound.tone))
            {
                return "mute";
            }

            foreach (List<Song> listSong in _song)
            {

                for (int i = 0; i < listSong.Count; i++)
                {

                    if (listSong[i].tone == sound.tone)
                    {

                        for (int j = i + 1; j < listSong.Count; j++)
                        {

                            tones.Add(listSong[j].tone);

                        }

                        result = string.Join("..", tones);
                        return result;

                    }

                }

            }

            return result;
        }
        
        


    }
}
