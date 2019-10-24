import * as React from 'react';
import { connect } from 'react-redux';
import helpers from './../axios/axios-wrap';

interface IMyComponentState {
    data: any
}

interface IMyComponentProps {}

class GameLevel extends React.Component<IMyComponentProps, IMyComponentState> {
    constructor(props : any) {
        super(props);
        this.state = { data: {} };
    }

    async componentDidMount() {
        let data = await helpers.getLevelInfo();
        data.data = JSON.parse(data.data.jsonObject);
        this.setState({ data });
        console.log(this.state.data.data.Level.Number);
    }

    render() {
        return (
            <div>
                <div className="level-title">Уровень 1 из 20: Название</div>
                <div className="level-text">Текст задания</div>
                <div className="level-hints">Подсказки</div>
                <div className="level-bonuses">Бонусы</div>
                <div className="level-penalties">Штрафные подсказки</div>

                <hr />

                <div>{JSON.stringify(this.state.data.data)}</div>

                <hr />
                {JSON.stringify(this.state.data)}
            </div>
        );
    }
};

export default connect()(GameLevel);
