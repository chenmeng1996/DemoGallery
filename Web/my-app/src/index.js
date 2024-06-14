import { Pane, WelcomeDialog, WelcomeDialogWithChildren } from './layout';

import App from './reduxDemo/components/App';
import {Clock} from './clock'
import { ContextDemo } from './context';
import { Example } from './hook/useEffectDemo';
import { Game } from './game';
import { LoginControl } from './login';
import { NameForm } from './form';
import { NumberList } from './list';
import { Provider } from 'react-redux';
import ReactDOM from 'react-dom/client';
import { createStore } from 'redux'
import { themes } from './theme-context';
import todoApp from './reduxDemo/reducers';

// ========================================

const root = ReactDOM.createRoot(document.getElementById("root"));

let store = createStore(todoApp)

root.render(
    // <Pane />
    <div>
        <Game/>
        <Clock/>
        <LoginControl/>
        <NumberList numbers={[1, 2, 3]}/>
        <NameForm/>
        <WelcomeDialog />
        <WelcomeDialogWithChildren />
        <ContextDemo theme={themes.dark}/>
        <Example/>
        {/* 让所有容器组件都可以访问store */}
        <Provider store={store}>
            <App />
        </Provider>,
    </div>
);