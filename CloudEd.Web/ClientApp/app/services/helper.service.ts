import { Injectable } from '@angular/core';


@Injectable()
export class HelperService{

    private readonly _newEntityId = '_undefinedId';

    public get undefinedId(): string {
        return this._newEntityId;
    }

    public isNewEntity(entityId: string): boolean {
        return entityId === this._newEntityId;
    }
}

