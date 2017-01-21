import { Routes } from '@angular/router';

import {AssessmentDetailComponent } from './assessment-detail.component';
import { AssessmentDetailEditorComponent } from './assessment-detail-editor.component';
import { ResultDetailComponent } from '../result/result-detail.component';
import { ResultEditorComponent } from '../result/result-editor.component';


export const ASSESSMENTDETAIL_ROUTES: Routes = [
    { path: 'detail', component: AssessmentDetailComponent },
    { path: 'edit/:id', component: AssessmentDetailEditorComponent },
    { path: 'question/:id', component: ResultDetailComponent }
];
