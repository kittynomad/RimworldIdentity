using RimWorld;
using Verse;

namespace Identity
{
    [StaticConstructorOnStartup]
    public static class Identity
    {
        static MyMod() //our constructor
        {
            Log.Message("Hello World!"); //Outputs "Hello World!" to the dev console.
        }
    }
}
