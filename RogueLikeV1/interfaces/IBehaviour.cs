using RogueLikeV1.Core;
using RogueLikeV1.Systems;

namespace RogueLikeV1.interfaces
{
    public interface IBehaviour
    {
        bool Act(Monster monster, CommandSystem commandSystem);
    }
}
