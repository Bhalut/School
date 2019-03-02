namespace CoreSchool.Entities
{
    public interface IPlace
    {
        string Direction { get; set; }

        void ClearPlace();
    }
}