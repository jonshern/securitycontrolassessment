import { AssessmentAnswer } from './assessmentanswer';


export class AssessmentReport {
    'id': string;
    'name': string;
    'assessmentType': string;
    'assessmentAnswers': Array<AssessmentAnswer>;
    'tags': string;
    'lastSnapshotDate': Date;
    'updateTimeStamp': Date;
    'createTimeStamp': Date;
    'overallMaturityScore': number;
    'levelOneScore': number;
    'levelTwoScore': number;
    'levelThreeScore': number;
    'levelFourScore': number;
    'levelFiveScore': number;
}
