
namespace Sparrow
{
    internal class EOM
    {

        public double[,] DCM;

        public float e0, e1, e2, e3;
        public float de0, de1, de2, de3;   // time derivative of each e0...e3

        public float dt = 1 / 60.0f;

        public float p, q, r;
        public float dp, dq, dr;

        public EOM()
        {
            e0 = 1f;
            DCM = new double[3, 3];
        }

        // Update is called once per frame
        public void FixedUpdate()
        {
            CalculateDpDqDr();

            CalculatePQR(dp, dq, dr);
            CalculateQuaternionDerivatives(e0, e1, e2, e3, p, q, r);
            CalculateQuaternionAngles(de0, de1, de2, de3);
            CalculateDCM(e0, e1, e2, e3);
        }

        public void CalculateDpDqDr()
        {

        }

        public void CalculatePQR(float dp, float dq, float dr)
        {
            p += dp * dt;
            q += dq * dt;
            r += dr * dt;
        }

        public void CalculateQuaternionDerivatives(float e0, float e1, float e2, float e3, float p, float q, float r)
        {
            float lambda = 1 - (e0 * e0 + e1 * e1 + e2 * e2 + e3 * e3);
            de0 = -0.5f * (e1 * p + e2 * q + e3 * r) + lambda * e0;
            de1 = 0.5f * (e0 * p + e2 * r - e3 * q) + lambda * e1;
            de2 = 0.5f * (e0 * q + e3 * p - e1 * r) + lambda * e2;
            de3 = 0.5f * (e0 * r + e1 * q - e2 * p) + lambda * e3;
        }

        public void CalculateQuaternionAngles(float de0, float de1, float de2, float de3)
        {
            e0 += de0 * dt;
            e1 += de1 * dt;
            e2 += de2 * dt;
            e3 += de3 * dt;
        }

        public void CalculateDCM(float e0, float e1, float e2, float e3)
        {
            DCM[0, 0] = (e0 * e0) + (e1 * e1) - (e2 * e2) - (e3 * e3);
            DCM[0, 1] = 2 * (e1 * e2 - e0 * e3);
            DCM[0, 2] = 2 * (e0 * e2 + e1 * e3);

            DCM[1, 0] = 2 * (e1 * e2 + e0 * e3);
            DCM[1, 1] = (e0 * e0) - (e1 * e1) + (e2 * e2) - (e3 * e3);
            DCM[1, 2] = 2 * (e2 * e3 - e0 * e1);

            DCM[2, 0] = 2 * (e1 * e3 - e0 * e2);
            DCM[2, 1] = 2 * (e2 * e3 + e0 * e1);
            DCM[2, 2] = (e0 * e0) - (e1 * e1) - (e2 * e2) + (e3 * e3);
        }
    }
}
