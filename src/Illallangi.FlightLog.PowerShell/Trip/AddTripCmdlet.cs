namespace Illallangi.FlightLog.PowerShell.Trip
{
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Add, Nouns.Trip)]
    public sealed class AddTripCmdlet : FlightLogCmdlet<ITrip>
    {
        #region Properties

        [Parameter(Mandatory = true)]
        public string Year { get; set; }

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public string Description { get; set; }

        #endregion

        #region Methods

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Repository.Create(new Trip
            {
                Year = this.Year, 
                Name = this.Name, 
                Description = this.Description,
            }));
        }

        #endregion
    }
}