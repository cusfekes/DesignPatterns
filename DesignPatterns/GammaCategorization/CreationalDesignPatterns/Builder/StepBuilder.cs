using System.Text;

namespace DesignPatterns.GammaCategorization.CreationalDesignPatterns.Builder
{
    public class StepBuilder
    {
        public static void Main()
        {
            UniversityCertificate uniCertificate = StartUniversity.Start().PassFirstYear(98).PassSecondYear(89).PassThirdYear(95).PassFourthYear(100).Graduate();
            Console.WriteLine(uniCertificate.ToString());
        }
    }

    public class UniversityCertificate
    {
        public int firstYearDegree { get; set; }

        public int secondYearDegree { get; set; }

        public int thirdYearDegree { get; set; }

        public int fourthYearDegree { get; set; }

        public bool isGraduated { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"First year degree:   { firstYearDegree }");
            str.AppendLine($"Second year degree:   { secondYearDegree }");
            str.AppendLine($"Third year degree:   { thirdYearDegree }");
            str.AppendLine($"Fourth year degree:   { fourthYearDegree }");
            str.AppendLine($"Is graduation successful?:   { isGraduated }");
            return str.ToString();
        }
    }

    public interface IFirstYear
    {
        public ISecondYear PassFirstYear(int degree);
    }

    public interface ISecondYear
    {
        public IThirdYear PassSecondYear(int degree);
    }

    public interface IThirdYear
    {
        public IFourthYear PassThirdYear(int degree);
    }

    public interface IFourthYear
    {
        public IGraduation PassFourthYear(int degree);
    }

    public interface IGraduation
    {
        public UniversityCertificate Graduate();
    }

    public class StudyUniversity : IFirstYear, ISecondYear, IThirdYear, IFourthYear, IGraduation
    {
        private UniversityCertificate certificate = new UniversityCertificate();

        public ISecondYear PassFirstYear(int degree)
        {
            certificate.firstYearDegree = degree;
            return this;
        }

        public IThirdYear PassSecondYear(int degree)
        {
            certificate.secondYearDegree = degree;
            return this;
        }

        public IFourthYear PassThirdYear(int degree)
        {
            certificate.thirdYearDegree = degree;
            return this;
        }

        public IGraduation PassFourthYear(int degree)
        {
            certificate.fourthYearDegree = degree;
            return this;
        }

        public UniversityCertificate Graduate()
        {
            if (certificate.firstYearDegree > 0 && certificate.secondYearDegree > 0 && certificate.thirdYearDegree > 0 && certificate.fourthYearDegree > 0)
                certificate.isGraduated = true;
            else
                certificate.isGraduated = false;
            return certificate;
        }
    }

    public class StartUniversity
    {
        public static IFirstYear Start()
        {
            return new StudyUniversity();
        }
    }
}
