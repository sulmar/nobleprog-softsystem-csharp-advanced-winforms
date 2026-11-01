namespace Lims.Problem
{
    // TODO: refaktoryzacja: zwykła klasa z danymi przekazywana przez konstruktor.
    // PROBLEM: statyczny singleton (DIP). Każda klasa może po niego sięgnąć, a z jej konstruktora
    // nie widać, że go potrzebuje. Test nie ustawi innego numeru bez zmiany stanu całej aplikacji.
    public sealed class LabSettings
    {
        public static LabSettings Instance { get; } = new LabSettings();

        private LabSettings()
        {
        }

        public string LabName { get; set; } = "Laboratorium Centralne";

        // Numer fikcyjny.
        public string DoctorPhone { get; set; } = "+48 500 000 000";
    }
}
