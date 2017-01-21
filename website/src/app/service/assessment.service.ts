import { Injectable } from '@angular/core';
import { Headers, Http, Response, RequestOptions } from '@angular/http';

import { AssessmentReport } from '../domain/assessmentreport';
import { AssessmentAnswer } from '../domain/assessmentanswer';
import { TemplateQuestion } from '../domain/templatequestion';

// import { ASSESSMENTS } from '../mock/mock-assessments';
// import { ASSESSMENTITEMS } from '../mock/mock-assessments';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';



@Injectable()
export class AssessmentService {

    private headers = new Headers({ 'Content-Type': 'application/json' });
    // private baseUrl = 'http://securityassessmentservices.azurewebsites.net/';
    // private baseUrl = 'http://localhost:28070/';

    // private assessmentUrl = 'api/AssessmentReport';

    private assessmentUrl = 'http://localhost:28070/api/AssessmentReport';
    private assessmentAnswerUrl = 'http://localhost:28070/api/AssessmentAnswer';
    private templateQuestionUrl = 'http://localhost:28070/api/TemplateQuestion';
    private createReportSnapshotUrl = 'http://localhost:28070/api/AssessmentReport/CreateReportSnapshot';



    // private assessmentUrl = 'http://securityassessmentservices.azurewebsites.net/api/AssessmentReport';
    // private assessmentAnswerUrl = 'http://securityassessmentservices.azurewebsites.net/api/AssessmentAnswer';
    // private templateQuestionUrl = 'http://securityassessmentservices.azurewebsites.net/api/TemplateQuestion';



    constructor(private http: Http) { }

    // getAssessmentList(): Promise<AssessmentReport[]> {
    //     return Promise.resolve(ASSESSMENTS);
    // }



    deleteAssessment(id: string) {
        const url = `${this.assessmentUrl}/${id}`;

        return this.http.delete(this.assessmentUrl)
            .map(this.extractData)
            .catch(this.handleError);

    }


    getAssessment(id: string) {
        const url = `${this.assessmentUrl}/${id}`;
        return this.http.get(url)
            .map((response: Response) => response.json());
    }



    getAssessmentAnswer(id: string) {
        const url = `${this.assessmentAnswerUrl}/${id}`;
        return this.http.get(url)
            .map((response: Response) => response.json()
            );
    }


    saveAssessmentAnswer(id: string, answer: AssessmentAnswer) {

        console.error('Saving Assessment Answer from the Service');

        const url = `${this.assessmentAnswerUrl}/${id}`;

        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.put(url, answer , options)
            .map(this.extractData)
            .catch(this.handleError);

        // return this.http.post(this.assessmentAnswerUrl, { answer }, options)
        //     .map(this.extractData)
        //     .catch(this.handleError);
    }

    saveReportSnapshot(id: string, comments: string) {

        console.error('Saving Report Snapshot');

        const url = `${this.createReportSnapshotUrl}/${id}`;
        console.error(url);

        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(url, comments, options)
            .map(this.extractData)
            .catch(this.handleError);

        // return this.http.post(this.assessmentAnswerUrl, { answer }, options)
        //     .map(this.extractData)
        //     .catch(this.handleError);
    }





    getAssessmentQuestions() {
        console.error('Getting Questions');
        return this.http.get(this.templateQuestionUrl)
            .map((response: Response) => response.json())
            .catch(this.handleError);

    }


    getAssessmentReports(): Observable<AssessmentReport[]> {
        return this.http.get(this.assessmentUrl)
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    createReport(name: string): Observable<AssessmentReport> {

        console.error('Saving Asessment Report with Name ' + name);

        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.assessmentUrl, { name }, options)
            .map(this.extractData)
            .catch(this.handleError);
    }


    private extractData(res: Response) {
        let body = res.json();
        // return body.data || {};

        let data = body.data || {};

        return data;
    }



    private handleError(error: Response | any) {
        // In a real world app, we might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }

}
