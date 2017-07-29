import { Injectable } from '@angular/core';

import { QuizCreateModel } from './../models/quizCreateModel';
import { QuestionViewModel } from './../models/questionViewModel';
import { AnswerCreateModel } from './../models/answerCreateModel';

import { QuizCreateModel } from './../models/quizCreateModel';
import { QuestionCreateModel } from './../models/questionCreateModel';
import { AnswerCreateModel } from './../models/answerCreateModel';

@Injectable()
export class QuizBackofficeService {
    private stubbedQuizez: QuizCreateModel[];
    public greeting: string = "Hello from my service!";

    constructor() {
        this.stubbedQuizez =
            [
                {
                    id: "dotnet-quiz",
                    title: "ASP.NET basics",
                    description: "It wiil help you test your knowledge of the robust and powerfull web development tool!",
                    questions: this.stubbedQuestions
                },
                {
                    id: "potato",
                    title: "Another ASP.NET basics",
                    description: "It wiil help you test your knowledge of the robust and powerfull web development tool!",
                    questions: this.stubbedQuestions
                },

            ];
    }

    public getAll(): QuizCreateModel[] {
        return this.stubbedQuizez;
    }

    get stubbedQuestions(): QuestionCreateModel[] {
        let stub: QuestionCreateModel[] =
            [
                {
                    id: this.randomId,
                    title: "Some title",
                    answers:
                    [
                        { id: this.randomId, body: "42", questionId: this.randomId, isSelected: false },
                        { id: this.randomId, body: "12", questionId: this.randomId, isSelected: false },
                        { id: this.randomId, body: "55", questionId: this.randomId, isSelected: false }
                    ],
                    selectedAnswer: null
                },

                {
                    id: this.randomId,
                    title: "What is your favourite meal?",
                    answers:
                    [
                        { id: this.randomId, body: "42", questionId: this.randomId, isSelected: false },
                        { id: this.randomId, body: "banana", questionId: this.randomId, isSelected: false },
                        { id: this.randomId, body: "55", questionId: this.randomId, isSelected: false }
                    ],
                    selectedAnswer: null
                },

                {
                    id: this.randomId,
                    title: "Banana?",
                    answers:
                    [
                        { id: this.randomId, body: "Yes", questionId: this.randomId, isSelected: false },
                        { id: this.randomId, body: "Of course!", questionId: this.randomId, isSelected: false },
                        { id: this.randomId, body: "42", questionId: this.randomId, isSelected: false },
                        { id: this.randomId, body: "42? 42!", questionId: this.randomId, isSelected: false }
                    ],
                    selectedAnswer: null
                }
            ];
        return stub;
    }

    private static counter: number = 0;

    private get randomId(): string {
        return `random-id-${QuizService.counter++}`;
    }
}

