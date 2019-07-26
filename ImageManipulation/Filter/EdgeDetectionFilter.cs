namespace ImageManipulation.Filter
{
    public class EdgeDetectionFilter : BaseFilter
    {
        public override double[,] Data { get; } = { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };

        public override double NormalizationRate => 1;

        public override double Bias => 0;

        public override int Size => 3;
    }
}
