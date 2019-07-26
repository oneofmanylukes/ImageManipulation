namespace ImageManipulation.Filter
{
    public class BlurFilter : BaseFilter
    {
        public override double[,] Data { get; } = { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } };

        public override double NormalizationRate => 1.0/16.0;

        public override double Bias => 0.0;

        public override int Size => 3;
    }
}
