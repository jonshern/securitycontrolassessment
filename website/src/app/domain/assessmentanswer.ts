
export class AssessmentAnswer {

    'id': string;
    'assessmentReportId': string;
    'questionId': string;
    'policyDefined': string;
    'policyDefinedScore': number;
    'controlImplemented': string;
    'controlImplementedScore': number;
    'controlAutomated': string;
    'controlAutomatedScore': number;
    'controlReporting': string;
    'controlReportingScore': number;
    'appliesTo': string;
    'comments': string;
    'updateTimeStamp': Date;
    'createTimeStamp': Date;
    'controlNumber': number;
    'controlId': number;
    'questionText': string;

    AssessmentAnswer()
    {
        this.id = '';
        this.assessmentReportId = '';
        this.questionId = '';
        this.policyDefined = '';
        this.policyDefinedScore = 0;
        this.controlImplemented = '';
        this.controlAutomatedScore = 0;
        this.controlAutomated = '';
        this.controlAutomatedScore = 0;
        this.controlReporting = '';
        this.controlReportingScore = 0;
        this.appliesTo = '';
        this.comments = '';
        this.questionText = '';
    }


}
