import { Component, Input, OnInit } from '@angular/core';
import { Response } from '@angular/http';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { Location } from '@angular/common';
import { Observable } from 'rxjs/Observable';




import { AssessmentService } from '../service/assessment.service';
import { AssessmentReport } from '../domain/assessmentreport';
import { AssessmentAnswer } from '../domain/assessmentanswer';
import { TemplateQuestion } from '../domain/templatequestion';


import 'rxjs/add/operator/switchMap';

@Component({
    selector: 'app-assessment-detail',
    templateUrl: './assessment-detail.component.html',
    styleUrls: ['./assessment-detail.component.css']
})
export class AssessmentDetailComponent implements OnInit {

    @Input()
    assessment: AssessmentReport;
    assessmentAnswers: AssessmentAnswer[];
    templateQuestions: Array<TemplateQuestion>;
    reportId: string;
    editMode: boolean;

    afterLoadTemplateQuestions: Array<TemplateQuestion>;


    assessmentList: Observable<AssessmentReport[]>;


    errorMessage: string;

    jsonData: string;

    constructor(private router: Router, private assessmentService: AssessmentService,
        private activatedRoute: ActivatedRoute, private location: Location) {


    }

    ngOnInit() {
        // this.getAssessment('485A7191-4290-4CE1-85C8-14A0AA26A917');
        this.reportId = this.activatedRoute.snapshot.params['id'];
        this.getAssessment(this.activatedRoute.snapshot.params['id']);
        this.getTemplateQuestions();

        // this.activatedRoute.params
        //     .switchMap((params: Params) => this.assessmentService.getAssessment(params['id']));
        // .subscribe(assessment => this.assessmentList = assessment,
        // error =>  this.errorMessage = <any>error);


    }


    getAssessment(id: string) {
        this.assessmentService.getAssessment(id)
            .subscribe(
            (data: AssessmentReport) => this.assessment = data
            );
    }

    getAnswerForQuestion(questionId: string): AssessmentAnswer {

        return;
    }

    getTemplateQuestions() {
        this.assessmentService.getAssessmentQuestions()
            .subscribe(
            (data: Array<TemplateQuestion>) => this.templateQuestions = data
            )
            ;
    }

    saveAssessmentSnapshot(id: string) {
        this.assessmentService.saveReportSnapshot(id, '')
            .subscribe(() => console.log('retrieved data')
            );

        this.location.back();
    }






    goBack(): void {


        for (let quest of this.templateQuestions) {
            console.log(quest.detail);
        }


        this.afterLoadTemplateQuestions = this.templateQuestions;

        // for (let answer of this.assessment.assessmentAnswers)
        // {
        //     console.log(answer);
        // }


        // this.location.back();
    }

    editAssessmentAnswer(id: string): void {
        this.router.navigate(['/resulteditor', id]);

    }

    // setAssessment(assessment: Observable<AssessmentReport>) {

    //     this.assessment = assessment;

    //     console.error(this.assessment);
    // }

}
