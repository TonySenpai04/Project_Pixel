
namespace Tony
{
    public class PetATK : IATK, IATKR, IATKS, ICR, ICD
    {
        private float atk;
        private float atkR;
        private float atkS;
        private float cR;
        private float cD;
        public PetATK(float atk, float atkR, float atkS,float cR,float cD )
        {
            this.atk = atk;
            this.atkR = atkR;
            this.atkS = atkS;
            this.cR = cR;
            this.cD = cD;

        }

        public float GetAtk()
        {
            return this.atk;
        }

        public float GetATKR()
        {
            return this.atkR;
        }

        public float GetATKS()
        {
            return this.atkS;
        }

        public float GetCD()
        {
            return this.cD;
        }

        public float GetCR()
        {
            return this.cR;
        }

        public void SetAtk(float value)
        {
            this.atk = value;
        }

        public void SetATKR(float value)
        {
            this.atkR = value;
        }

        public void SetATKS(float value)
        {
            this.atkS= value;
        }

        public void SetCD(float value)
        {
            this.cD = value;
        }

        public void SetCR(float value)
        {
            this.cR = value;
        }

        public void SetData(float atk)
        {
            this.atk = atk;

        }
    }
}
