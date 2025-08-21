using System;
using System.Collections.Generic;
using System.Windows.Forms;
using mRemoteNG.Connection;
using mRemoteNG.Container;


namespace mRemoteNG.Tree
{
	public class SelectedConnectionDeletionConfirmer : IConfirm<ConnectionInfo>
    {
        private readonly Func<string, string, MessageBoxButtons, MessageBoxIcon, DialogResult> _confirmationFunc;

        public SelectedConnectionDeletionConfirmer(Func<string, string, MessageBoxButtons, MessageBoxIcon, DialogResult> confirmationFunc)
        {
            _confirmationFunc = confirmationFunc;
        }

        public bool Confirm(ConnectionInfo deletionTarget)
        {
            if (deletionTarget == null)
                return false;

            var deletionTargetAsContainer = deletionTarget as ContainerInfo;
            if (deletionTargetAsContainer != null)
                return deletionTargetAsContainer.HasChildren()
                    ? UserConfirmsNonEmptyFolderDeletion(deletionTargetAsContainer)
                    : UserConfirmsEmptyFolderDeletion(deletionTargetAsContainer);
            return UserConfirmsConnectionDeletion(deletionTarget);
        }

        //CBH 暂未使用
        public bool Confirm(IReadOnlyList<ConnectionInfo> deletionTargets) //Collection
        {
            if (deletionTargets == null)
                return false;

            return UserConfirmsSelectedNodeDeletion();
        }

        private bool UserConfirmsEmptyFolderDeletion(AbstractConnectionRecord deletionTarget)
        {
            var messagePrompt = string.Format(Language.strConfirmDeleteNodeFolder, deletionTarget.Name);
            return PromptUser(messagePrompt);
        }

        private bool UserConfirmsNonEmptyFolderDeletion(AbstractConnectionRecord deletionTarget)
        {
            var messagePrompt = string.Format(Language.strConfirmDeleteNodeFolderNotEmpty, deletionTarget.Name);
            return PromptUser(messagePrompt);
        }

        private bool UserConfirmsConnectionDeletion(AbstractConnectionRecord deletionTarget)
        {
            var messagePrompt = string.Format(Language.strConfirmDeleteNodeConnection, deletionTarget.Name);
            return PromptUser(messagePrompt);
        }
        private bool UserConfirmsSelectedNodeDeletion()
        {
            var messagePrompt = Language.strConfirmDeleteNodeSelected;
            return PromptUser(messagePrompt);
        }

        private bool PromptUser(string promptMessage)
        {
            var msgBoxResponse = _confirmationFunc.Invoke(promptMessage, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return msgBoxResponse == DialogResult.Yes;
        }
    }
}