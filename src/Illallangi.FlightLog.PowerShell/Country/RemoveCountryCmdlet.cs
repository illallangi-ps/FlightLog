namespace Illallangi.FlightLog.PowerShell.Country
{
    using System.Linq;
    using System.Management.Automation;

    using Illallangi.FlightLog.Model;

    [Cmdlet(VerbsCommon.Remove, Nouns.Country, DefaultParameterSetName = "Id", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    public sealed class RemoveCountryCmdlet : FlightLogCmdlet<ICountry>
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Id")]
        public int? Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Value")]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            foreach (var o in this.Repository.Retrieve(new Country { Id = this.Id, Name = this.Name }).ToList().Where(o => this.ShouldProcess(o.ToString(), VerbsCommon.Remove)))
            {
                this.Repository.Delete(o);
            }
        }
    }
}