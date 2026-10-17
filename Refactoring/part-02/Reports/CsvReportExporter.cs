namespace RefactoringLab.Part02.Reports;

public class CsvReportExporter : Exporter
{

    protected override string Format(List<string[]> rows)
        => string.Join(Environment.NewLine, rows.Select(r => string.Join(",", r)));

}

// only provide the csv behaviour , but when calling still use exporter.Export that contains the template method and only the format behaviour
// is different between the 3 exporters