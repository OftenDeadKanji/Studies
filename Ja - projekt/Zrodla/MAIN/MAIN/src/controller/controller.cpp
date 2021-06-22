#include "../pch.h"

Controller::Controller() : mode(1), condition(true), updatePath(false), updateDllChoice(false), updateThreadsNumber(false), cooldown(0.1), lastTime(0), newTime(0)
{
	//wybieranie pliku z równaniami
	views[0] = new View;

	views[0]->addText(FILE_INFO, new Text("Prosze wskazac plik z rownaniami", 0.15 * System::getInstance().getDisplayWidth(), 0.2 * System::getInstance().getDisplayHeight()));
	views[0]->addControl(new Button("DALEJ", 0.8 * System::getInstance().getDisplayWidth(), 0.8 * System::getInstance().getDisplayHeight(), CONTROL_NEXT, true));
	views[0]->addControl(new Button("Przegladaj", 0.4 * System::getInstance().getDisplayWidth(), 0.35 * System::getInstance().getDisplayHeight(), CONTROL_FILE, true));

	//wybieranie w¹tków
	views[1] = new View;

	views[1]->addText(THREAD_INFO, new Text("Prosze poprzez suwak dobrac liczbe watkow", 0.05 * System::getInstance().getDisplayWidth(), 0.2 * System::getInstance().getDisplayHeight()));
	views[1]->addControl(new Button("WSTECZ", 0.1 * System::getInstance().getDisplayWidth(), 0.8 * System::getInstance().getDisplayHeight(), CONTROL_BACK, true));
	views[1]->addControl(new Button("DALEJ", 0.8 * System::getInstance().getDisplayWidth(), 0.8 * System::getInstance().getDisplayHeight(), CONTROL_NEXT, true));
	views[1]->addSlider(new Slider(0.15 * System::getInstance().getDisplayWidth(), 0.45 * System::getInstance().getDisplayHeight(), 0.7 * System::getInstance().getDisplayWidth(), 0.05 * System::getInstance().getDisplayHeight(), 1, 64));

	//wybieranie DLL
	views[2] = new View;

	views[2]->addText(DLL_INFO, new Text("Prosze wybrac biblioteke", 0.25 * System::getInstance().getDisplayWidth(), 0.1 * System::getInstance().getDisplayHeight()));
	views[2]->addControl(new Button("WSTECZ", 0.1 * System::getInstance().getDisplayWidth(), 0.8 * System::getInstance().getDisplayHeight(), CONTROL_BACK, true));
	RadioButtons* radio = new RadioButtons(0.38 * System::getInstance().getDisplayWidth(), 0.25 * System::getInstance().getDisplayHeight(), 1);
	radio->addRadioButton("ASM");
	radio->addRadioButton("C++");
	views[2]->addRadio(radio);
	views[2]->addControl(new Button("Uruchom", 0.4 * System::getInstance().getDisplayWidth(), 0.4 * System::getInstance().getDisplayHeight(), CONTROL_RUN, true));
	views[2]->addText(TIME_INFO, new Text("Czas algorytmu:", 0.3 * System::getInstance().getDisplayWidth(), 0.6 * System::getInstance().getDisplayHeight()));
	views[2]->addTimeText(new Text("0", 0.65 * System::getInstance().getDisplayWidth(), 0.6 * System::getInstance().getDisplayHeight()));
	model = new Model;

	file = al_create_native_file_dialog(NULL, "Plik wejsciowy z rownaniami", "*.txt", ALLEGRO_FILECHOOSER_FILE_MUST_EXIST);
}

Controller::~Controller()
{
	for (auto iter : views)
		if (iter != nullptr)
			delete iter;

	delete model;

	al_destroy_native_file_dialog(file);
}

int Controller::getMode()
{
	return this->mode;
}

void Controller::run()
{

	while (condition) {
		//danej wej - C
		processInput();

		//aktualizacja - M
		updateModel();

		//rysowanie - V
		updateView();
	}
}

void Controller::processInput()
{
	newTime = (double)clock() / (double)CLOCKS_PER_SEC;
	while (al_get_next_event(views[mode - 1]->getEventQueue(), &event))
		switch (event.type) {
		case ALLEGRO_EVENT_DISPLAY_CLOSE:
			condition = false;
			break;
		case ALLEGRO_EVENT_MOUSE_BUTTON_DOWN:
			switch (views[mode - 1]->getPressedControlType()) {
			case CONTROL_FILE:
				al_show_native_file_dialog(NULL, file);
				if (al_get_native_file_dialog_count(file) > 0)
					filePath = al_get_native_file_dialog_path(file, 0);
				updatePath = true;
				break;
			case CONTROL_NEXT:
				if (newTime - lastTime > cooldown) {
					lastTime = (double)clock() / (double)CLOCKS_PER_SEC;
					mode++;
				}
				break;
			case CONTROL_BACK:
				if (newTime - lastTime > cooldown) {
					lastTime = (double)clock() / (double)CLOCKS_PER_SEC;
					mode--;
				}
				break;
			case CONTROL_SLIDER:
				updateThreadsNumber = true;// threadsNumber = views[mode - 1]->getSlider().getValue();
				break;
			case CONTROL_RADIO_BUTTONS:
				updateDllChoice = true;
				break;
			case CONTROL_RUN:
				model->setThreadsNumber(views[mode - 2]->getSlider().getValue());
				model->calculate();
				views[mode - 1]->setModelTime(model->getTime());
				break;
			}
		}
}

void Controller::updateModel()
{
	if (updatePath) {
		model->setPath(filePath);
		updatePath = false;
		model->loadEquations();
	}
	if (updateThreadsNumber) {
		model->setThreadsNumber(views[mode-1]->getSlider().getValue());
		updateThreadsNumber = false;
	}
	if (updateDllChoice) {
		views[mode - 1]->update();
		model->setDllChoice((DllChoice)views[mode - 1]->getRadio().getChoice());
		updateDllChoice = false;
	}
}

void Controller::updateView()
{
	views[mode - 1]->update();
	views[mode - 1]->draw();
}
