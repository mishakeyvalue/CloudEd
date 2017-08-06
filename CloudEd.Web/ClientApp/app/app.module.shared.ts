import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './components/main/app/app.component'
import { NavMenuComponent } from './components/main/navmenu/navmenu.component';
import { HomeComponent } from './components/main/home/home.component';
import { FetchDataComponent } from './components/front/fetchdata/fetchdata.component';

import { QuizComponent } from './components/front/quiz/quiz.component';
import { QuestionComponent } from './components/front/question/question.component';

import { QuizBuilderComponent } from './components/backoffice/quizBuilder/quizBuilder.component';
import { QuestionBuilderComponent } from './components/backoffice/questionBuilder/questionBuilder.component';
import { QuizResultComponent } from "./components/front/quiz/quizResult.component";
import { QuestionResultComponent } from "./components/front/question/questionResult.component";

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        FetchDataComponent,
        HomeComponent,
        QuizComponent,
        QuizResultComponent,
        QuestionComponent,
        QuestionResultComponent,
        QuizBuilderComponent,
        QuestionBuilderComponent,
    ],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'backoffice', component: QuizBuilderComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'quiz', component: QuizComponent},
            { path: '**', redirectTo: 'home' }
        ]),
        FormsModule,
        ReactiveFormsModule
        
    ]
};
