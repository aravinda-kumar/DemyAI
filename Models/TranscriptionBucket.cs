namespace DemyAI.Models;
public class TranscriptionBucket {

    public string BucketName { get; set; }

    public string BucketRegion { get; set; }

    public string AssumeRoleArn { get; set; }

    public bool AllowApiAccess { get; set; }
}
