using System;

namespace Skat
{
    public class Afgift
    {
        /// <summary>
        /// Tager prisen af bilen som argument og returnerer afgiften
        /// </summary>
        /// <param name="pris">prisen på bilen</param>
        /// <returns>afgiften på bilen udfra prisen</returns>
        public int BilAfgift(int pris)
        {
            double bilAfgift = 0;
            if (pris < 0)
            {
                throw new ArgumentException("pris kan ikke være under 0");
            }

            if (pris <= 200000)
            {
                bilAfgift = pris * 0.85;
            }

            else
            {
                bilAfgift = (pris * 1.50) - 130000;
            }

            return (int)bilAfgift;
        }

        /// <summary>
        /// Tager prisen på elbilen som argument og returnerer afgiften
        /// </summary>
        /// <param name="pris">prisen på elbilen</param>
        /// <returns>afgiften på elbilen</returns>
        public int ElBilAfgift(int pris)
        {
            double elBilAfgift = BilAfgift(pris) * 0.20;
            return (int)elBilAfgift;
        }
    }
}
