import { Injectable } from '@angular/core';
import { Headers, Http, Response, RequestOptions } from '@angular/http';

import { AssessmentReport } from '../domain/assessmentreport';
import { AssessmentAnswer } from '../domain/assessmentanswer';
import { TemplateQuestion } from '../domain/templatequestion';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';



@Injectable()
export class AssessmentAnswerService {

  constructor() { }

}
