import { Component, OnInit } from '@angular/core';

import { QuizService } from './../../../services/quiz.service';

import { QuizViewModel } from "../../../models/quizViewModel";
import { LearningRoutineModel, LearningBit } from "../../../models/learningRoutine";

@Component({
    selector: 'my-quiz',
    templateUrl: './quiz.component.html',
    providers: [QuizService]
})
export class QuizComponent implements OnInit {
    private learnignRoutine: LearningRoutineModel = {learningBits: []};

    public quizes: QuizViewModel[];
    public currentQuiz: QuizViewModel;
    public isQuizStarted: boolean = false;
    public currentQuizId: string;

    constructor(private quizService: QuizService)
    { }

    ngOnInit(): void {
        this.quizService.getAll().then(quizes => {
            this.quizes = quizes;
        });
    }

    get welcomeMessage(): string {
        return "Welcome to our cloud quiz application!";
    }

    public questionOnAnswered(bit: LearningBit): void {
        let bits = this.learnignRoutine.learningBits;
        for (let i = 0; i < bits.length; i++) {
            if (bits[i].questionId == bit.questionId) {
                bits[i] = bit;
                return;
            }                
        }
        bits.push(bit); console.log(bits);
    }

    public loadQuiz(currentQuizId: string): void {
        this.isQuizStarted = true;
        this.currentQuiz = this.quizes.find((q) => q.id === currentQuizId);
    }
    
}
