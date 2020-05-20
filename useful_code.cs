// INotifyPRopertyChanged - allows UI to update when we change the value of a property
//To Support OneWay or TwoWay binding
//https:\//docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8
    public class TimeAttendance : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int idUser { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        public string Commodity { get; set; }
        public string Exception { get; set; }
        public string RequestType { get; set; }
        public string RequestId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Activity { get; set; }
        double totalHours;
        public double TotalHours
        {
            set
            {
                if (totalHours != value)
                {
                    totalHours = value;
                    OnPropertyChanged("TotalHours");
                }
            }
            get
            {
                return totalHours;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }