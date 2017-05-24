﻿using Xamarin.Forms;

namespace SecuritySampleApp
{
	public class SettingsPage : ContentPage
	{
		public SettingsPage(LaneModel laneModelTapped)
		{
			var viewModel = new SettingsViewModel(laneModelTapped);
			BindingContext = viewModel;

			#region create the IsOpen Switch
			var isOpenSwitch = new SwitchCell
			{
				Text = "Is Open"
			};
			isOpenSwitch.SetBinding(SwitchCell.OnProperty, nameof(viewModel.IsOpen));
			#endregion

			#region Create the Needs Maintenance Switch
			var needsMaintenanceSwitch = new SwitchCell
			{
				Text = "Needs Maintenance"
			};
			needsMaintenanceSwitch.SetBinding(SwitchCell.OnProperty, nameof(viewModel.NeedsMaintenance));
			#endregion

			#region create the IP Address Entry
			var ipAddressText = new EntryCell
			{
				Label = "IP Address",
				HorizontalTextAlignment = TextAlignment.End
			};
			ipAddressText.SetBinding(EntryCell.TextProperty, nameof(viewModel.IPAddress));
			#endregion

			#region Create Image Cell
			var imageCell = new ImageCell();
			imageCell.SetBinding(ImageCell.ImageSourceProperty, nameof(viewModel.ImageCellIcon));
			#endregion

			#region Create the Icon Toggle Button
			var iconToggleButton = new Button();
			iconToggleButton.SetBinding(Button.CommandProperty, nameof(viewModel.IconToggleButtonCommand));
			iconToggleButton.SetBinding(Button.TextProperty, nameof(viewModel.ToggleButtonText));
			#endregion

			#region create the TableView
			var tableView = new TableView
			{
				Intent = TableIntent.Settings,
				Root = new TableRoot
				{
					new TableSection{
						isOpenSwitch,
						needsMaintenanceSwitch,
						ipAddressText,
						imageCell
					}
				}
			};
			#endregion

			#region Create StackLayout to Include a Button
			var settingsStack = new StackLayout
			{
				Children ={
					tableView,
					iconToggleButton
				}
			};
			#endregion

			NavigationPage.SetTitleIcon(this, "cogwheel_navigation");

			Title = $"Lane {laneModelTapped.ID + 1} Settings";
			Content = settingsStack;
		}
	}
}

