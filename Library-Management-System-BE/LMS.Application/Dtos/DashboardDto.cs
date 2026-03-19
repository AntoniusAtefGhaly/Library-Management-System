namespace LMS.Application.Dtos;

public class DashboardDto
{
    public int TransactionCount { get; set; }
    public int ReturnedCount { get; set; }
    public int MembersCount { get; set; }
    public int OverdueCount { get; set; }
    public List<ChartDto> TopUsers { get; set; }
    public List<ChartDto> TopBooks { get; set; }
    public List<ChartDto> TopCategories { get; set; }
    public List<ChartDto> TopAuthers { get; set; }
}

public class ChartDto
{
    public string Text { get; set; }

    public int Value { get; set; }
}