using MyGuitarBag.Sdk.Resources.Interfaces;

namespace MyGuitarBag.Sdk
{
    public interface IMyGuitarBagClient
    {
        IGuitarResource Guitar { get; set; }
    }
}
