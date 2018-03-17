using Cargo;
using StrongName;

namespace Manager
{
    class Manager
    {
        static void Main(string[] args)
        {            
            MonsterTrack monsterTrack = new MonsterTrack();
            Track track = new Track();            
            monsterTrack.MonsterTrackInfo();
            track.TrackInfo();
            StrongNameMonster strongNameMonster = new StrongNameMonster();
            strongNameMonster.StrongMonsterTrackInfo();
        }
    }
}
