using System.ServiceModel;

namespace BierenServiceLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class RadenService : IRadenService
    {
        private const decimal AlcoholDuvel = 8.5M;
        private int _beurten;

        public RaadResultaat RaadDuvelAlcohol(decimal alcohol)
        {
            _beurten++;
            if (alcohol < AlcoholDuvel)
                return new RaadResultaat {Hint = Hint.Hoger, Beurten = _beurten};
            return alcohol > AlcoholDuvel ? new RaadResultaat {Hint = Hint.Lager, Beurten = _beurten} : new RaadResultaat {Hint = Hint.Correct, Beurten = _beurten};
        }
    }
}