import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AssessmentListComponent } from './assessment/assessment-list.component';
import { AssessmentDetailComponent } from './assessment/assessment-detail.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AssessmentCreateComponent } from './assessment/assessment-create.component';
import { ASSESSMENTDETAIL_ROUTES } from './assessment/assessment-detail.routes';

import { ResultEditorComponent } from './result/result-editor.component';
import { ResultDetailComponent } from './result/result-detail.component';

const routes: Routes = [
    { path: '', component: AssessmentListComponent},
    // { path: '', redirectTo: '/assessments', pathMatch: 'full'},
    { path: 'dashboard', component: DashboardComponent },
    { path: 'assessment/:id', component: AssessmentDetailComponent },
    { path: 'assessment/:id', component: AssessmentDetailComponent},
    { path: 'assessments', component: AssessmentListComponent},
    { path: 'createassessment', component: AssessmentCreateComponent},
    { path: 'resulteditor/:id', component: ResultEditorComponent}
];


@NgModule({
    imports: [ RouterModule.forRoot(routes)],
    exports: [ RouterModule]
})

export class AppRoutingModule {}
